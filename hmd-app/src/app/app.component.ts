import { WriteVarExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { PostService } from './services/post.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title : string = 'hmd-app';
  tracks : any;

  constructor(private service : PostService) {}

  getTracks() {
    this.tracks = this.service.getPosts();
  }

  ngOnInit(): void {
    this.service.getPosts()
        .subscribe(response => {
          this.tracks = response;
          console.log(this.tracks);
        });
  }
}