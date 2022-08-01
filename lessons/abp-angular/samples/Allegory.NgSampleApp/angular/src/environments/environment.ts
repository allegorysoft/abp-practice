import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'NgSampleApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44313',
    redirectUri: baseUrl,
    clientId: 'NgSampleApp_App',
    responseType: 'code',
    scope: 'offline_access NgSampleApp',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44313',
      rootNamespace: 'Allegory.NgSampleApp',
    }
  },
} as Environment;