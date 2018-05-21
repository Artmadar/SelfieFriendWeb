import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { MdDialog, MdDialogRef } from '@angular/material';
import { DialogResult } from './components/modal-windows/dialog-result/dialog-result.component';
import { ModelProfile } from 'app/models/model-profile';
import { ProfileWorkService } from 'app/services/profile-work';
import { Ng2IzitoastService } from 'ng2-izitoast';
import { AddPhotoDialog } from 'app/components/modal-windows/add-photo-tape/add-photo-tape.dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [ProfileWorkService],
})
export class AppComponent implements OnInit, AfterViewChecked {
  reseivedProfile: ModelProfile; // данные профиля
  public count;
  public auth = false
  returnUrl: any;
  Add = true; // переменная для того чтобы разделять Dialog, откуда он был вызван
  constructor(public dialog: MdDialog,
    private router: Router,
    private profielWorkService: ProfileWorkService,
    public iziToast: Ng2IzitoastService) { }

  openDialog(Add: boolean) {
    const dialogRef = this.dialog.open(DialogResult, {
      data: [{
        Add: this.Add
      }]
    });
  }


  openDialogPhotoAdd() {
    this.dialog.open(AddPhotoDialog, {
      data: [{
        data: 'add'
      }]
    })
  }
  ngOnInit() {
    this.count = 1;
  }
  ngAfterViewChecked() {

    const access_token = (localStorage.getItem('access_token'))
    if (access_token === null) {
      this.auth = true;
    } else {
      this.auth = false;
      const activeRoute = window.location.pathname;
      if (activeRoute === '/tape' || activeRoute === '/tapeImage' && this.count === 1) {
        this.profielWorkService.getProfile(access_token)
          .subscribe((response2) => {
            this.count = 0;
            this.reseivedProfile = response2;
          })
      }


    }
  }

  exitToVk() {
    localStorage.clear();
  }

}
