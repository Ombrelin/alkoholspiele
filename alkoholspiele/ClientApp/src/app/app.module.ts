import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { GameComponent } from './game/game.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { ChartsModule } from 'ng2-charts';
import {MatDialogModule} from '@angular/material/dialog';
import { AddJokeDialogComponent } from './add-joke-dialog/add-joke-dialog.component';
import { PlayComponent } from './play/play.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GameComponent,
    AddJokeDialogComponent,
    PlayComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'game/:id', component: GameComponent },
      { path: 'play/:id', component: PlayComponent },
    ]),
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressSpinnerModule,
    ChartsModule,
    MatDialogModule,
    MatProgressBarModule,
    MatIconModule
  ],
  entryComponents: [AddJokeDialogComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
