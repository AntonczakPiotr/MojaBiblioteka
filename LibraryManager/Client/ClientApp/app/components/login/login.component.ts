import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

import { Credentials } from '../../models/Credentials';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit, OnDestroy {

    private subscription: Subscription;

    brandNew: boolean;
    credentials: Credentials = { login: '', password: '' };

    constructor(private router: Router, private activatedRoute: ActivatedRoute) { }

    ngOnInit(): void {
        this.subscription = this.activatedRoute.queryParams.subscribe(
            (param: any) => {
                this.brandNew = param['brandNew'];
                this.credentials.login = param['login'];
            });
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
