import { Component, OnInit } from '@angular/core';
import { ReturnedImage } from '../_models/returnedimage';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-images',
  templateUrl: './images.component.html',
  styleUrls: ['./images.component.css']
})
export class ImagesComponent implements OnInit {

  constructor(private userService: UserService, private alertify: AlertifyService, private route: ActivatedRoute) { }
  images: ReturnedImage[];

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.images = data['images'];
      console.log(this.images);
  });
}
}
