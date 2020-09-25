import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent, PipeFormatDate } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ListaClienteComponent } from './cliente/lista-cliente/lista-cliente.component';
import { CadastroClienteComponent } from './cliente/cadastro-cliente/cadastro-cliente.component';

import { ClienteService } from './cliente/cliente.service';

import { registerLocaleData } from '@angular/common';
import ptBr from '@angular/common/locales/pt';
registerLocaleData(ptBr)

import { NgxMaskModule, IConfig } from 'ngx-mask'

const maskConfig: Partial<IConfig> = {
  validation: false,
};

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ListaClienteComponent,
    CadastroClienteComponent,
    PipeFormatDate
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxMaskModule.forRoot(maskConfig),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'lista-cliente', component: ListaClienteComponent },
      { path: 'cadastro-cliente', component: CadastroClienteComponent },
      { path: 'cadastro-cliente/:id', component: CadastroClienteComponent },
    ])
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt'},
    ClienteService, 
    PipeFormatDate
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
