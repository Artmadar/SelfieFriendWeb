import { Component, OnInit, ViewChild } from '@angular/core';
import { Image, ButtonsConfig, ButtonsStrategy, ButtonType, ButtonEvent } from 'angular-modal-gallery';
import { RequestLocalServer } from 'app/services/request.local.server';
import { Ng2IzitoastService } from 'ng2-izitoast';

@Component({
    selector: 'app-tape-image',
    templateUrl: './tape-image.component.html',
    styleUrls: ['./tape-image.component.scss'],
    providers: [RequestLocalServer],
})
export class TapeImageComponent implements OnInit {
    public text;
    public isCompleted = true;
    dropdownSettings = {};
    dropdownList = [];
    categoryID;
    searchButton = true;
    sbrosButton = true;
    selectedItems = [];
    customButtonsConfigExtUrlNewTab: ButtonsConfig = {
        visible: true,
        strategy: ButtonsStrategy.CUSTOM,
        buttons: [
            {
                className: 'ext-url-image',
                type: ButtonType.DOWNLOAD,
                title: 'Купить изображение'
            },
            {
                className: 'close-image',
                type: ButtonType.CLOSE
            }
        ]
    };
    images: Image[] = [];
    constructor(private requestLocalServer: RequestLocalServer, public iziToast: Ng2IzitoastService) {
        this.requestLocalServer.getPhoto().subscribe(response => {
            this.images = [];
            for (let photo of response) {
                this.images.push(new Image(photo.OfferingId, { img: photo.ImagePath, description: photo.Description }))
            }

            this.isCompleted = false;
            this.iziToast.success({
                title: 'Лента загружена',
                progressBar: false,
                message: 'Количество изображения ' + this.images.length,
                position: 'topCenter',
                timeout: 2000,
            })

        })

        this.requestLocalServer.getCategory().subscribe(response => {
            console.log(response);
            for (let item of response) {
                this.dropdownList.push({ id: item.Id, itemName: item.Name })
            }

        })

        this.dropdownSettings = {
            singleSelection: true,
            text: "Выберите категорию",
            enableSearchFilter: true,
            classes: "myclass custom-class",
        };
    }
    ngOnInit() {
    }

    onItemSelect(event) {
        this.categoryID = event.id;
        this.searchButton = false;
    }
    public search(text) {
        this.isCompleted = true;
        this.requestLocalServer.searcPhotos(text, this.categoryID).subscribe(response => {
            this.searchButton = true;
            console.log(response);
            if (response.length === 0) {
                this.isCompleted = false;
                this.iziToast.info({
                    title: 'Поиск не дал результатов',
                    progressBar: false,
                    message: 'Количество изображения ' + response.length,
                    position: 'topCenter',
                    timeout: 2000,
                })
            } else {
                this.images = [];
                for (let photo of response) {
                    this.images.push(new Image(photo.OfferingId, { img: photo.ImagePath, description: photo.Description }))
                }
                this.isCompleted = false;
            }
            this.sbrosButton = false;
        })
    }


    public reset() {
        this.isCompleted = true;
        this.text = '';
        this.selectedItems = [];
        this.requestLocalServer.getPhoto().subscribe(response => {
            this.images = [];
            for (let photo of response) {
                this.images.push(new Image(photo.OfferingId, { img: photo.ImagePath, description: photo.Description }))
            }
            this.searchButton = false;
            this.isCompleted = false;
            this.iziToast.success({
                title: 'Лента загружена',
                progressBar: false,
                message: 'Количество изображения ' + this.images.length,
                position: 'topCenter',
                timeout: 2000,
            })
        })
    }
    onCustomButtonBeforeHook(event: ButtonEvent) {
        this.requestLocalServer.buyPhotos(event.image.id).subscribe(res => {
            console.log(res);
        })
    }
}
