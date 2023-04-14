import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { UploadService } from '../../services/upload/upload.service';

@Component({
  selector: 'hmd-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  @ViewChild('formFiles') formFilesInput : any;

  @Input() updateTrackList : Function;

  private uploadLimit : number = 20000000;

  public successes : number = 0;
  public errors : number = 0;
  public message : string = '';

  constructor(private httpClient : HttpClient, private service : UploadService) {}

  ngOnInit(): void {
  }

  async uploadFiles() {
    let formFiles : any = this.formFilesInput.nativeElement.files;
    
    let formData = new FormData();

    if(formFiles.length > 0) {
        for(let x = 0; x < formFiles.length; x++) {
          formData.append('files', formFiles.item(x));    
        }
    }

    let formDataSize = 0;

    for(let pair of formData.entries()) {
      if (pair[1] instanceof Blob) 
        formDataSize += pair[1].size;
      else
      formDataSize += pair[1].length;
    }

    if (formDataSize < this.uploadLimit) {
      this.service.postFiles(formData).subscribe(response => {
        this.successes = response.successes;
        this.errors = response.errors;
        this.updateTrackList();
        this.message = 'Upload successfull!';
      });
    } else {
      this.message = 'Files are too big! (' + formDataSize + ')';
    }
  }
}