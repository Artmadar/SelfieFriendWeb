import { Route } from '@angular/router';
import { TapeComponent } from './components/tape-news/tape.component';
import { ConnectionResolver } from './route.resolve';

export const ChatRoutes: Route[] = [
	{
     path: 'tape',
     component: TapeComponent,
     resolve: { connection: ConnectionResolver }
	}
];   