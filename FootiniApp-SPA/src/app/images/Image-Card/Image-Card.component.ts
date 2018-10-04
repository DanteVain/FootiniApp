import { Component, OnInit, Input } from '@angular/core';
import { ReturnedImage } from '../../_models/returnedimage';

@Component({
  selector: 'app-image-card',
  templateUrl: './Image-Card.component.html',
  styleUrls: ['./Image-Card.component.css']
})
export class ImageCardComponent implements OnInit {
  @Input() image: ReturnedImage;
  constructor() { }

  ngOnInit() {
  }

}
