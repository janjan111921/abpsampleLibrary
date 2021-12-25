import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOrEditBooksComponent } from './create-or-edit-books.component';

describe('CreateOrEditBooksComponent', () => {
  let component: CreateOrEditBooksComponent;
  let fixture: ComponentFixture<CreateOrEditBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateOrEditBooksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateOrEditBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
