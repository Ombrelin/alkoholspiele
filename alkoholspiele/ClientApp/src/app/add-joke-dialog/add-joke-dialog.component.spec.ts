import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddJokeDialogComponent } from './add-joke-dialog.component';

describe('AddJokeDialogComponent', () => {
  let component: AddJokeDialogComponent;
  let fixture: ComponentFixture<AddJokeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddJokeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddJokeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
