import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { MdDialog } from '@angular/material';
import { SignalR, ISignalRConnection, BroadcastEventListener } from 'ng2-signalr';

import { ModelTape } from '../../models/tape-model';
import { RequestLocalServer } from '../../services/request.local.server';
import { BuyOffering } from '../../models/model-buy-offering';
import { DialogSend } from '../modal-windows/dialog-buy-an-offer/dialog.send.to.local.component';
import { DataSevice } from '../../services/data.sevice';
import { ProfileWorkService } from '../../services/profile-work';
import { ModelProfile } from 'app/models/model-profile';


@Component({
  moduleId: module.id,
  selector: 'tape',
  templateUrl: './tape.component.html',
  styleUrls: ['./tape.scss'],
  providers: [RequestLocalServer, DataSevice, ProfileWorkService]

})

export class TapeComponent {
  reseivedProfile: ModelProfile; 
  private _connection: ISignalRConnection;
  // массив для вывода ленты
  receivedTape: Array<ModelTape>;
  checked = false;
  pusto = false;

  returnUrl: object; // переменная для перенаправления по адресу в случае если нет токена
  offerCancel: BuyOffering = new BuyOffering();
  count = 3; // посты
  startposition = 0; // наша позиция
  countChek = false; // флаг который нужен для прекращения загрузки

  constructor(public dialog: MdDialog,
    private requestLocalServer: RequestLocalServer,
    private router: Router,
    private _signalR: SignalR,
    private route: ActivatedRoute,
    private dataService: DataSevice,
    private profielWorkService: ProfileWorkService) {

    console.log('ConnectionResolver. Resolving...');
    this._signalR.connect().then((connection) => {
      this._connection = connection;
      this.Info();
    });

  }

  addItems(startIndex, endIndex) {
    this.requestLocalServer.getTape(this.startposition, this.count).subscribe((response) => {
      if (response !== '') {
        for (let i = 0; i < response.length; i++) {
          this.receivedTape.push(response[i])
        }
        this.countChek = false;
        this.startposition = this.receivedTape.length

      } else if (response === '') {
        this.countChek = true;

      }

    })
  }

  onScrollDown() {

    this.startposition = this.receivedTape.length;
    const start = this.startposition;

    if (this.countChek !== true) {
      this.addItems(start, this.count);
      this.countChek = true;
    }
  }

  // открытие и передача ID в Dialog
  openDialog(modeltape: ModelTape) {
    this.checked = true;
    const id = modeltape.OfferingId;
    const dialogRef = this.dialog.open(DialogSend, {
      data: id
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        modeltape.Checked = true;
      }

    })

  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit(startposition: number, count: number) {
    // необходимо для того чтобы пользователь не смог перейти на этот компонент без токена
    const access_token = (localStorage.getItem('access_token'))
    // условие на проверку токена в localStorage
    if (access_token == null) {
      this.returnUrl = this.router.navigateByUrl('**');
    }

    // подписываемся на получение ленты
    this.requestLocalServer.getTape(this.startposition, this.count).subscribe((response) => {
      this.receivedTape = response;
      if (response == []) {
        this.pusto = true;
      }
    })
  }

  cancelOffer(modeltape: ModelTape) {
    const ID = modeltape.OfferingId;
    this.requestLocalServer.postCancelOffer(ID).subscribe((response) => {
      console.log(response);
      if (response.ok) {
        modeltape.Checked = false;
      }
    })
  }

  Info() {
    const onMessageSent$ = new BroadcastEventListener<string>('offeringAdd');
    this._connection.listen(onMessageSent$);
    onMessageSent$.subscribe((response: string) => {
      const json = JSON.parse(response);
      this.receivedTape.unshift(json[0]);
    });

  }
}
