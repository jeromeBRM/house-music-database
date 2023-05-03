import { Component, Input, ViewChild } from '@angular/core';
import { UpdaterService } from '../../services/updater/updater.service';

@Component({
  selector: 'hmd-updater',
  templateUrl: './updater.component.html',
  styleUrls: ['./updater.component.css']
})
export class UpdaterComponent {
  @ViewChild('input') input : any;

  @Input() public id : string;
  @Input() public property : string;
  @Input() public type : any;
  @Input() public value : any;

  constructor(private service : UpdaterService) {}

  async update() {
    this.value = this.input.nativeElement.value;
    let formData = new FormData();

    formData.append('apiObjectId', this.id);   
    formData.append('property', this.property);   
    formData.append('value', this.value);   
    
    let response = this.service.update(formData).subscribe(response => {

    });
  }
}