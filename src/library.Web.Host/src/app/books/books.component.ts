import { ThrowStmt } from '@angular/compiler';
import { Component, Inject, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto, PagedResultDto } from '@shared/paged-listing-component-base';
import { GetBookOutputList,BookServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsComponentRef } from 'ngx-bootstrap/component-loader';
import { BsModalService,BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';



class BooksInput extends PagedRequestDto{
  keyword:string;
}

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html'
  // styleUrls: ['./books.component.css']
})
export class BooksComponent extends PagedListingComponentBase<GetBookOutputList> implements OnInit {
  keyword = '';
  bookList: GetBookOutputList[];
  advanceFiltersVisible = false;
  

  constructor(
    injector:Injector,
    private _bookServiceProxy: BookServiceProxy,
    private _modalService: BsModalService,

  ) { 
    super(injector);
  }

  ngOnInit(): void {
     this.refresh();
  }

  protected list(request: BooksInput, pageNumber: number, finishedCallback: Function): void {
    
    request.keyword = this.keyword;

  this._bookServiceProxy.getAll(
    request.keyword,
    request.skipCount,
    request.maxResultCount).pipe(
      finalize(() => {
        finishedCallback();
      })
    ).subscribe(result=>{
      this.bookList = result.items;
      this.showPaging(result, pageNumber);
    });

    
  
}

protected delete(entity: GetBookOutputList): void {
  abp.message.confirm(
  this.l('BooktDeleteWarningMessage', entity.book.title),
  undefined,
    (result: boolean) => {
      if (result) {
        this._bookServiceProxy.delete(entity.book.id).subscribe(() => {
          abp.notify.success(this.l('SuccessfullyDeleted'));
          this.refresh();
        });
      }
    }
  );
}

  createOrEditBooks(Id?:number){
    let createOrEditBooks: BsModalRef;
    if(!Id){
      createOrEditBooks = this._modalService.show(
        createOrEditBooks,
        {
          class: 'modal-lg',
        }
      );
    }
    else{
      createOrEditBooks = this._modalService.show(
        createOrEditBooks,
        {
          class: 'modal-lg',
          initialState: {
            Id: Id,
          },
        },
      );
    }
    createOrEditBooks.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

}
