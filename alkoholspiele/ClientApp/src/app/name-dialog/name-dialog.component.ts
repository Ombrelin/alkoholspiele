import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-name-dialog',
  templateUrl: './name-dialog.component.html',
  styleUrls: ['./name-dialog.component.css']
})
export class NameDialogComponent implements OnInit {

  name: string;
  disabled = true;

  constructor() { }

  ngOnInit() {
  }

  handleChange() {
    this.disabled = this.name.length === 0;
  }
}
