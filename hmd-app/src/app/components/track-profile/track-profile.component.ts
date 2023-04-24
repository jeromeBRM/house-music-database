import { Component, Input } from '@angular/core';
import { Scale } from '../../model/scale';
import { ScalesService } from '../../services/scales/scales.service';

@Component({
  selector: 'hmd-track-profile',
  templateUrl: './track-profile.component.html',
  styleUrls: ['./track-profile.component.css']
})
export class TrackProfileComponent {
  @Input() public id : string;

  public scales : Scale[];
  
  constructor(private service : ScalesService) {}

  getScales() {
    let response = this.service.getScales(this.id);
    return response;
  }

  ngOnInit(): void {
    this.service.getScales(this.id)
        .subscribe(response => {
          this.scales = response;
        });
  }
}