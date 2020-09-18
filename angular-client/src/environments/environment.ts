// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const idpBase = "https://localhost:5001";
export const apiBase = "https://localhost:6001";
export const angularBase = "http://localhost:4200";


export const environment = {
  production: false,
  apiBase,
  openIdConnectSettings: {
    authority: `${idpBase}`,
    client_id: "angular-client",
    redirect_uri: `${angularBase}/signin-oidc`,
    post_logout_redirect_uri: `${angularBase}/`,
    slient_redirect_uri: `${angularBase}/redirect_silentrenew`,
    scope: "scope1 openid profile address email phone",
    response_type: "id_token token",
    automaticSilentRenew: true
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
