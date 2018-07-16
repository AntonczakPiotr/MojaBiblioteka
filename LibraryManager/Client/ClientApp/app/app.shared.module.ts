import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule, XHRBackend } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { RegisterComponent } from './components/register/register.component';

import { LoginComponent } from './components/login/login.component';
import { UserService } from './services/user.service';
import { LocalStorageModule } from '@ngx-pwa/local-storage';
import { StartViewComponent } from './components/loggedUser/startView/startView.component';
import { AuthGuard } from './auth.guard';
import { AuthenticateXHRBackend } from './authenticate-xhr.backend';
import { StartViewDataService } from './components/loggedUser/startView/startView.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        LoginComponent,
        RegisterComponent,
        StartViewComponent
    ],
    imports: [
        LocalStorageModule,
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            { path: 'loggedUser/startView', component: StartViewComponent, canActivate: [AuthGuard] },
            { path: '**', redirectTo: 'login' }
        ])
    ],
    providers: [UserService, AuthGuard, StartViewDataService, {
        provide: XHRBackend,
        useClass: AuthenticateXHRBackend
    }]
})
export class AppModuleShared {
}
