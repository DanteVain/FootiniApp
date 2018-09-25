import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-Administrator',
  templateUrl: './Administrator.component.html',
  styleUrls: ['./Administrator.component.css']
})
export class AdministratorComponent implements OnInit {

  constructor() { }

  ngOnInit() {

  }

}
