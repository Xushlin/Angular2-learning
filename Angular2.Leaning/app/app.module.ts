import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
//import { ModalModule } from 'ng2-bootstrap';
import { AppService} from './app.service';
import { AppComponent } from './app.component';
import { AboutComponent } from './about/about.component';
import { ExampleComponent } from './example/example.component';
import { EmployeeModule } from './employee/employee.module';
import { TodoModule } from './todo/todo.module';
import { routes } from './app.routes';
import './vendor'

@NgModule({
  imports: [BrowserModule,
            HttpModule,
            JsonpModule,
            RouterModule.forRoot(routes),
            TodoModule,
            EmployeeModule,
            FormsModule,
  ],
    declarations: [AppComponent,
                   AboutComponent,
                   ExampleComponent],
    providers:[AppService],
    bootstrap: [AppComponent]
})
export class AppModule {}