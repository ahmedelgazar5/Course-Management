import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseComponent } from './Course/Component/course/course.component';
import { AddCoursesComponent } from './AddCourses/Component/add-courses/add-courses.component';
import { CourseDetailsComponent } from './CourseDetails/Component/course-details/course-details.component';


const routes: Routes = [
  { path: 'courses', component: CourseComponent },
  { path: 'courses/create', component: AddCoursesComponent },
  { path: 'courses/create/:id', component: AddCoursesComponent },

  { path: 'courses/:id', component: CourseDetailsComponent },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
