import { Component, Input } from '@angular/core';
import { Scale } from '../../model/scale';

@Component({
  selector: 'hmd-scale',
  templateUrl: './scale.component.html',
  styleUrls: ['./scale.component.css']
})
export class ScaleComponent {
  @Input() public scale : Scale;
  
  @Input() onUpdate : Function;
}