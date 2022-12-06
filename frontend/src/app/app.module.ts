import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { PartComponent } from './models/part/part.component';
import { HomeComponent } from './home/home.component';
import { TestComponent } from './models/test/test.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { MainContentComponent } from './main-content/main-content.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { MaterialPersianDateAdapterComponent } from './shared/material.persian-date.adapter/material.persian-date.adapter.component';
//import { PartDetailComponent } from './models/part/part-detail/part-detail.component';

 @NgModule({
  declarations: [ 
    AppComponent,   
    PartComponent, HomeComponent, TestComponent, SideBarComponent, MainContentComponent,
     NavbarComponent, FooterComponent, MaterialPersianDateAdapterComponent
     
  ],
  imports: [
    FormsModule, 
    BrowserModule,
    HttpClientModule, //MatToolbarModule,
    RouterModule.forRoot(
      [ { path: '', component: HomeComponent } ,
       // { path: 'part-detail/:id', component: PartDetailComponent } ,
        { path: 'part-detail', component: TestComponent } ,
        { path: 'part-detail/:id', component: TestComponent } ,
        { path: 'Part', component: PartComponent }     
        

     ])
     
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  
}
