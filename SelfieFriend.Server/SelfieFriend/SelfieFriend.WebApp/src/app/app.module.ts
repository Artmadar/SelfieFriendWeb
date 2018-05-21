import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, APP_BASE_HREF, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { MaterialModule } from '@angular/material';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ImageUploadModule } from 'ng2-imageupload';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { NgxPaginationModule } from 'ngx-pagination';
import { SignalRModule, SignalRConfiguration, SignalR } from 'ng2-signalr';
import { GoTopButtonModule } from 'ng2-go-top-button';
import { NgSemanticModule } from 'ng-semantic/ng-semantic';
import { NgBoxModule } from 'ngbox/ngbox.module';
import { NgBoxService } from 'ngbox/ngbox.service';
import { NgxGalleryModule } from 'ngx-gallery';
import { CrystalGalleryModule } from 'ngx-crystal-gallery/components';
import { PageSliderModule } from 'ng2-page-slider';
import { AnimateInModule } from 'ngx-animate-in';
import { Ng2IziToastModule } from 'ng2-izitoast';
import 'hammerjs';
import 'mousetrap';
import { ModalGalleryModule } from 'angular-modal-gallery';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown/angular2-multiselect-dropdown';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxMagicSearchModule } from 'ngx-magicsearch';

import { TapeImageComponent } from 'app/components/tape-image/tape-image.component';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './components/home/welcome.component'
import { PageNotFound } from './components/page-not-found/PageNotFound.component'
import { TapeComponent } from './components/tape-news/tape.component';
import { ProfileComponent } from './components/profile/profile.component';
import { DialogResult } from './components/modal-windows/dialog-result/dialog-result.component';
import { DialogSend } from './components/modal-windows/dialog-buy-an-offer/dialog.send.to.local.component';
import { DialogPreview } from './components/modal-windows/dialog-preview-image/dialog.preview.component';
import { AddPhotoDialog } from './components/modal-windows/add-photo-tape/add-photo-tape.dialog'
import { AccessToken } from './components/auth-access/access.token.component';
import { ProfileMyOffers } from './components/profile-my-offers/profile-my-offers.component';
import { ProfileMyApplications } from './components/profile-my-applications/profile-my-applications.component';
import { ProfileApplicatonsForMe } from './components/profile-applications-for-me/profile-applications-for-me.component';
import { ConnectionResolver } from './route.resolve';
import { TarifPlanComponent } from './components/tarif-plans/tarif-plans.component'
import { GeneralInfoComponent } from 'app/components/general-profile-info/general-profile-info.component';




export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.hubName = 'OfferingHub';
  c.url = 'http://alexmadar70rus-001-site1.btempurl.com:80';
  return c;
}

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    PageNotFound,
    TapeComponent,
    AccessToken,
    ProfileComponent,
    DialogResult,
    DialogSend,
    DialogPreview,
    AddPhotoDialog,
    ProfileMyOffers,
    ProfileMyApplications,
    ProfileApplicatonsForMe,
    TarifPlanComponent,
    GeneralInfoComponent,
    TapeImageComponent,
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    HttpModule,
    BrowserAnimationsModule,
    GoTopButtonModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ImageUploadModule,
    InfiniteScrollModule,
    NgxPaginationModule,
    NgSemanticModule,
    NgBoxModule,
    NgxGalleryModule,
    CrystalGalleryModule,
    PageSliderModule,
    AnimateInModule,
    SignalRModule.forRoot(createConfig),
    ModalGalleryModule.forRoot(),
    AngularMultiSelectModule,
    Ng2IziToastModule,
    Ng2SearchPipeModule,
    NgxMagicSearchModule,
    RouterModule.forRoot([
      { path: 'welcome', component: WelcomeComponent },
      { path: 'tapeImage', component: TapeImageComponent },
      { path: 'tape', component: TapeComponent },
      { path: 'accesstoken', component: AccessToken },
      { path: 'tarif', component: TarifPlanComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'generalProfile', component: GeneralInfoComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', component: PageNotFound }
    ])
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    DialogResult,
    DialogSend,
    DialogPreview,
    AddPhotoDialog
  ],
  providers: [ConnectionResolver, NgBoxService]
})
export class AppModule {
}
