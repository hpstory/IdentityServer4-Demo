import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OpenIdConnectService } from '../open-id-connect.service';

@Component({
  selector: 'ac-signin-oidc',
  templateUrl: './signin-oidc.component.html',
  styleUrls: ['./signin-oidc.component.scss']
})
export class SigninOidcComponent implements OnInit {

  constructor(
    private oidc: OpenIdConnectService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.oidc.userLoaded$.subscribe(userLoaded => {
      if(userLoaded){
        this.router.navigate(['./dashboard']);
      }
    })

    this.oidc.handleCallBack();
  }

}
