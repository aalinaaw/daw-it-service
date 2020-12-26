import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
import {UserModuleModule} from "./user-module/user-module.module";
import {ServiceModuleModule} from "./service-module/service-module.module";

@NgModule({
    imports: [AppModule, ServerModule, ModuleMapLoaderModule, UserModuleModule, ServiceModuleModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
