import { enableProdMode } from '@angular/core';
import 'expose-loader?jQuery!jquery';
import '../node_modules/signalr/jquery.signalR.js';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule);
