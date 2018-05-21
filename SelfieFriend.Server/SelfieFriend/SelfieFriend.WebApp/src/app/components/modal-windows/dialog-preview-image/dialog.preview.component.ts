import { OnInit, Component, Input, Inject } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { RequestLocalServer } from '../../../services/request.local.server';
import { MyOfferings } from '../../../models/model-my-offer';
import { MD_DIALOG_DATA } from '@angular/material';

@Component({
    selector: 'dialog-preview',
    templateUrl: './dialog.preview.html',
    styleUrls: ['./dialog.preview.css'],
})

export class DialogPreview {
    // здесь хранится путь к картинке который передается из компонента profile
    public PhotoPath: string;

    constructor(public dialogRef: MdDialogRef<DialogPreview>,
        @Inject(MD_DIALOG_DATA) public data: any) {
        this.PhotoPath = data;
    }


}


