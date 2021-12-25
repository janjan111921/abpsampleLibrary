import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { BookServiceProxy, CreateOrEditBook } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-or-edit-books',
  templateUrl: './create-or-edit-books.component.html',
  // styleUrls: ['./create-or-edit-books.component.css']
})
export class CreateOrEditBooksComponent extends AppComponentBase implements OnInit {

  @Output() onSave = new EventEmitter<any>();
  book: CreateOrEditBook = new CreateOrEditBook();
  // categoryList: GetCategoryOutputList[] = [];
  saving = false;
  Title = 'Create Book';
  Id:number;

  constructor(public bsModalRef: BsModalRef,
    private _bookServiceProxy: BookServiceProxy,
    injector: Injector
    ) { super(injector);}

  ngOnInit(): void {
    if(this.Id){
      this._bookServiceProxy.getBookById(this.Id).subscribe(result=>{
          this.book = result;
          this.Title = 'Edit Books';
      });
  }
  // this._categoryserviceProxy.getAll().subscribe(result=>{
  //   this.categoryList = result;
  //   console.log(this.categoryList);
  // });
  }

  save():void{
    this.saving = true;
    this._bookServiceProxy.createOrEdit(this.book).subscribe( () => {
      this.saving = false;
      this.notify.info(this.l('SavedSuccessfully'));
      this.bsModalRef.hide();
      this.onSave.emit();
    },
    () => {
      this.saving = false;
    });
  }
}
