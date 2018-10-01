using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FootiniApp.API.Data;
using FootiniApp.API.Dtos;
using FootiniApp.API.helpers;
using FootiniApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FootiniApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userid}/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public ImagesController(IImageRepository imageRepository, IUserRepository userRepository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _mapper = mapper;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }
        [HttpGet("{id}", Name = "GetPhoto")]

        public async Task<IActionResult> GetPhoto(int id){

            var imageFromRepo = await _userRepository.GetImage(id);
            var image = _mapper.Map<ImageForReturnDto>(imageFromRepo);

            return Ok(image);
        }

        [HttpPost]
        public async Task<IActionResult> AddImageForUser(int userid, [FromForm]ImageForCreationDto imageForCreationDto)
        {
            if(userid != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();

            var userFromRepo = await _userRepository.GetUser(userid);

            var file = imageForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if(file.Length > 0){
                using(var stream = file.OpenReadStream()){
                    var uploadParams = new ImageUploadParams(){
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);

                }
            }

            imageForCreationDto.Url = uploadResult.Uri.ToString();
            imageForCreationDto.PublicId = uploadResult.PublicId;
            imageForCreationDto.AssociatedText = "hello";
            

            var image = _mapper.Map<Image>(imageForCreationDto);
            userFromRepo.Images.Add(image);

            if(await _userRepository.SaveAll()){
                var imageToReturn = _mapper.Map<ImageForReturnDto>(image);
                return CreatedAtRoute("GetImage", new {id = image.Id}, imageToReturn );
            }

            return BadRequest("Could not add image");
        }

    }
}