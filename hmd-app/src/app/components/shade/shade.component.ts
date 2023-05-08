import { Component, Input, OnInit } from '@angular/core';
import { Scale } from '../../model/scale';

@Component({
  selector: 'hmd-shade',
  templateUrl: './shade.component.html',
  styleUrls: ['./shade.component.css']
})
export class ShadeComponent implements OnInit {
  @Input() public scales : Scale[];
  public shadeColor : string;

  updateShade() {
    this.shadeColor = 'rgb('
    + (255 - this.scales[0].value * 2.55)
    + ','
    + (255 - this.scales[1].value * 2.55)
    + ','
    + (255 - this.scales[2].value * 2.55)
    +')';
  }

  ngOnInit(): void {
    this.updateShade();
  }
}