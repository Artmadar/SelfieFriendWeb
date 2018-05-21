import { Router, ActivatedRoute, Params } from '@angular/router';
import { OnInit, Component, Input, Inject } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms'
import { Http, Headers } from '@angular/http';
import { RequestLocalServer } from '../../../services/request.local.server';
import { MdDialog, MdDialogRef } from '@angular/material';
import { BuyOffering } from '../../../models/model-buy-offering';
import { TapeComponent } from '../../tape-news/tape.component';
import { MD_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'dialog-send',
  templateUrl: './dialog.send.to.local.html',
  styleUrls: ['./dialog.send.to.local.scss'],
  providers: [RequestLocalServer],

})

export class DialogSend implements OnInit {
  formGroup: FormGroup;
  // переменная для хранения ID карточки
  private offeringId: number
  checked: boolean;
  offerBuy: BuyOffering = new BuyOffering();

  constructor(public dialogRef: MdDialogRef<DialogSend>,
    @Inject(MD_DIALOG_DATA) public data: any,
    private requestLocalServer: RequestLocalServer) {
    this.formGroup = new FormGroup({
      text: new FormControl('', [Validators.required, Validators.minLength(1)])
    });
    this.offeringId = data
  }

  // отправка данных о покупке
  SubmitOffer() {
    this.offerBuy.OfferingId = this.offeringId;
    this.requestLocalServer.postBuyOffer(this.offerBuy).subscribe((response) => {
      if (response.ok) {
        this.checked = true;
      }
    });
  }

  ngOnInit() {
    this.dialogRef.updateSize('28%', '40%');
  }

}