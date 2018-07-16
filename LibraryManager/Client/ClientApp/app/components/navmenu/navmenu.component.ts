import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Subscription } from 'rxjs';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {

    status: boolean;
    subscription: Subscription;

    constructor(private userService: UserService) {
    }

    logout() {      
        this.userService.logout();
    }

    ngOnInit(): void {
        this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
