import { Injectable } from '@angular/core';
import { User, UserManager } from 'oidc-client';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OpenIdConnectService {

  private userManager = new UserManager(environment.openIdConnectSettings);

  private currentUser: User;

  get userAvailable(): boolean{
    return this.currentUser != null;
  }

  get user(): User{
    return this.currentUser;
  }

  userLoaded$ = new ReplaySubject<boolean>(1);

  constructor() {
    this.userManager.clearStaleState();
    this.userManager.getUser().then(user => {
      if(user){
        this.currentUser = user;
        this.userLoaded$.next(true);
      }else{
        this.currentUser = null;
        this.userLoaded$.next(false);
      }
    }).catch(() => {
      this.currentUser = null;
      this.userLoaded$.next(false);
    })
    // 用户登陆
    this.userManager.events.addUserLoaded(user => {
      this.currentUser = user;
      this.userLoaded$.next(true);
    });
    // 用户登出
    this.userManager.events.addUserUnloaded(() => {
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
  }

  // 跳转登陆
  triggerSignIn(){
    this.userManager.signinRedirect().then(() => {
      console.log("triggerSignIn");
    });
  }

  handleCallBack(){
    this.userManager.signinRedirectCallback().then(user => {
      this.currentUser = user;
    });
  }

  handleSilentCallback(){
    this.userManager.signinSilentCallback().then(user => {
      this.currentUser = user;
    });
  }

  // 跳转登出
  triggerSignOut(){
    this.userManager.signoutRedirect().then(() => {
      console.log("triggerSignOut");
    });
  }
}
