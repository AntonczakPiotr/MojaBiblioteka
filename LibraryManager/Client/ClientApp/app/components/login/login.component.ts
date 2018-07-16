import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

import { Credentials } from '../../models/Credentials';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit, OnDestroy {

    private subscription: Subscription;

    errors: string[] = [];

    brandNew: boolean;
    isRequesting: boolean;
    submitted: boolean = false;
    credentials: Credentials = { login: '', password: '' };

    constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

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

    login({ value, valid }: { value: Credentials, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = [];
        if (valid) {
            this.userService.login(value.login, value.password)
                .finally(() => this.isRequesting = false)
                .subscribe(
                    result => {
                        if (result) {                        
                            this.router.navigate(['/loggedUser/startView']);
                        }
                    },
                    errors => this.errors.push(errors));
        }
    }
}
