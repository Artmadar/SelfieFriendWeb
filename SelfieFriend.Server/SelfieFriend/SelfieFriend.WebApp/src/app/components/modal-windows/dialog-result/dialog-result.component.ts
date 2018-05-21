import { Router, ActivatedRoute, Params, } from '@angular/router';
import { OnInit, Component, Input, Inject, Pipe } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { MdDialog, MdDialogRef } from '@angular/material';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms'
import { ImageResult, ResizeOptions } from 'ng2-imageupload';
import { Observable } from 'rxjs/Rx';
import { ModelOffer } from '../../../models/model-add-offer';
import { MyOfferings } from '../../../models/model-my-offer';
import { ChangeOffer } from '../../../models/model-change-offer';
import { RequestLocalServer } from '../../../services/request.local.server';
import { MD_DIALOG_DATA } from '@angular/material';



@Component({
    selector: 'dialog-result',
    templateUrl: './dialog-result.component.html',
    styleUrls: ['./dialog.result.scss'],
    providers: [RequestLocalServer],

})

export class DialogResult implements OnInit {
    formGroup: FormGroup;

    // картинка в base64
    private base64textString;
    src: string;
    // режем картинку
    resizeOptions: ResizeOptions = {
        resizeMaxHeight: 200,
        resizeMaxWidth: 200
    };
    returnUrl: any; // переменная для перенаправления по адресу в случае если нет токена
    MyOffer: Array<ChangeOffer>;
    change: ChangeOffer = new ChangeOffer();

    // тут хранится то что мы отсылаем на сервак(описание,стоимость, заголовок и base64 картинка)
    offer: ModelOffer = new ModelOffer();

    constructor(public dialogRef: MdDialogRef<DialogResult>,
        private requestLocalServer: RequestLocalServer,
        private router: Router,
        @Inject(MD_DIALOG_DATA) public data: any) {
        // валидатор
        this.formGroup = new FormGroup({
            description: new FormControl('', [Validators.required, Validators.minLength(1)]),
            cost: new FormControl('', [Validators.required]),
            title: new FormControl('', [Validators.required, Validators.minLength(1)])
        });
        // принимаем данные 
        this.MyOffer = this.data;
        console.log(this.MyOffer);
    }
    // отслеживаем выбранный файл
    selected(imageResult: ImageResult) {
        this.src = imageResult.resized
            && imageResult.resized.dataURL
            || imageResult.dataURL;

        let photo = imageResult.file;
        if (photo) {
            let reader = new FileReader();
            reader.onload = this._handleReaderLoaded.bind(this);
            reader.readAsBinaryString(photo);
        }
    }

    // base64
    _handleReaderLoaded(readerEvt) {
        var binaryString = readerEvt.target.result;
        this.base64textString = btoa(binaryString);
        console.log(this.base64textString);


    }

    // метод для отправки предложения
    submit() {
        this.offer.Photo = this.base64textString;
        this.requestLocalServer.postOffer(this.offer).subscribe((responce) => {
            console.log(responce);
            // location.reload();
        })
    }
    submitChange(Description: string, Title: string, Cost: string, Id: number) {
        this.change.Photo = this.base64textString;
        this.change.Cost = Cost;
        this.change.Description = Description;
        this.change.Title = Title;
        this.change.Id = Id;
        this.requestLocalServer.postChangeOffer(this.change).subscribe((response) => {

            console.log(response);
            location.reload();
        })
    }
    ngOnInit() {
        // необходимо для того чтобы пользователь не смог перейти на этот компонент без токена
        var access_token = (localStorage.getItem('access_token'))
        // условие на проверку токена в localStorage
        if (access_token == null) {
            this.returnUrl = this.router.navigateByUrl('**');
            this.dialogRef.close();
        }
        // Размер Dialog
        this.dialogRef.updateSize('35%', '82%');


    }

}