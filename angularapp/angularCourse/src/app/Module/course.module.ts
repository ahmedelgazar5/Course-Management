import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseRoutingModule } from './course-routing.module';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCoursesComponent } from './AddCourses/Component/add-courses/add-courses.component';
import {ToastModule} from 'primeng/toast';



@NgModule({
  declarations: [AddCoursesComponent],
  imports: [
    CommonModule,
    CourseRoutingModule,
    InputTextModule,
    ReactiveFormsModule,
    FormsModule,
    ToastModule
  ]
})
export class CourseModule { }
