import { Router, ActivatedRoute, Params, } from '@angular/router';
import { OnInit, Component, Inject } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { MD_DIALOG_DATA } from '@angular/material';
import { ImageResult, ResizeOptions } from 'ng2-imageupload';
import { RequestLocalServer } from '../../../services/request.local.server';
import { ModelOffer } from 'app/models/model-add-offer';

@Component({
    selector: 'app-add-photo',
    templateUrl: './add-photo-tape.dialog.html',
    styleUrls: ['./add-photo-tape.dialog.scss'],
    providers: [RequestLocalServer],

})

// tslint:disable-next-line:component-class-suffix
export class AddPhotoDialog implements OnInit {
    offer: ModelOffer = new ModelOffer();
    dropdownList = [];
    selectedItems = [];
    dropdownSettings = {};

    public category = [];
    returnUrl: any;
    // картинка в base64
    private base64textString;
    src: string;
    // режем картинку
    resizeOptions: ResizeOptions = {
        resizeMaxHeight: 200,
        resizeMaxWidth: 200
    };
    constructor(public dialogRef: MdDialogRef<AddPhotoDialog>,
        private requestLocalServer: RequestLocalServer,
        private router: Router,
        @Inject(MD_DIALOG_DATA) public data: any) {
        // принимаем данные
        console.log(data);
    }
    ngOnInit() {
        // необходимо для того чтобы пользователь не смог перейти на этот компонент без токена
        const access_token = (localStorage.getItem('access_token'))
        // условие на проверку токена в localStorage
        if (access_token == null) {
            this.returnUrl = this.router.navigateByUrl('**');
            this.dialogRef.close();
        }
        // Размер Dialog
        this.dialogRef.updateSize('35%', '82%');

        this.requestLocalServer.getCategory().subscribe(response => {
            console.log(response);
            for (let item of response) {
                this.dropdownList.push({ id: item.Id, itemName: item.Name })
            }
        })

        this.dropdownSettings = {
            singleSelection: true,
            text: "Select Category",
            enableSearchFilter: true,
            classes: "myclass custom-class",
        };
    }
    onItemSelect(event) {
       this.offer.CategoryId = event.id;
    }
    // отслеживаем выбранный файл
    selected(imageResult: ImageResult) {
        this.src = imageResult.resized
            && imageResult.resized.dataURL
            || imageResult.dataURL;

        const photo = imageResult.file;
        if (photo) {
            const reader = new FileReader();
            reader.onload = this._handleReaderLoaded.bind(this);
            reader.readAsBinaryString(photo);
        }
    }

    // base64
    _handleReaderLoaded(readerEvt) {
        const binaryString = readerEvt.target.result;
        this.base64textString = btoa(binaryString);
        console.log(this.base64textString);
    }

    submit() {
        this.offer.Photo = this.base64textString;
        this.requestLocalServer.postPhoto(this.offer).subscribe((responce) => {
            console.log(responce);
            // location.reload();
        })
    }
}
