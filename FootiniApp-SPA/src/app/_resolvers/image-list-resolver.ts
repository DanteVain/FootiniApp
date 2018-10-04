import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRoute, ActivatedRouteSnapshot } from "@angular/router";
import { UserService } from "../_services/user.service";
import { User } from "../_models/user";
import { AlertifyService } from "../_services/alertify.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { ReturnedImage } from "../_models/returnedimage";
import { ImageService } from "../_services/Image.service";
import { AuthService } from "../_services/auth.service";

@Injectable()
export class ImageListResolver implements Resolve<ReturnedImage[]> {
    // tslint:disable-next-line:max-line-length
    constructor(private imageService: ImageService, private router: Router, private alertify: AlertifyService, private authService: AuthService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<ReturnedImage[]> {
        return this.imageService.getImages(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alertify.error('Problem getting data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}