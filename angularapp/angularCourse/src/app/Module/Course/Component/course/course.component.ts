import { Router } from '@angular/router';
import { ConfirmationService, LazyLoadEvent, Message, MessageService } from 'primeng/api';
import { ISessions, Icourse, IcoursesTypes } from '../../../Model/icourse';
import { CourseService } from '../../../Service/course.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  show: Boolean = true;
  courses: Icourse[] = [];
  coursesTypes: IcoursesTypes[] = [];
  sessions: ISessions[] = [];
  totalRecords: number = 0;
  loading!: boolean;
  pageSize: number = 4;
  pageIndex: number = 0;
  name: string = '';
  price: any;
  courseTypeId: any = null;
  id: number = 0;

  selectedCourseType: {} = {};
  messages1: Message[] = [];

  constructor(
    private messageService: MessageService,
    private courseService: CourseService,
    private router: Router,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.courseService.getCoursesTypes().subscribe(coursesTypes => this.coursesTypes = coursesTypes);
    this.courseService.getSessions().subscribe(result => this.sessions = result);
  }

  loadCourses(event: any) {
    console.log(event);
    if (event == null) {
      this.pageIndex = 0;
    }
    else
      this.pageIndex = event.first / event.rows;

    this.courseService.getCourse(this.pageSize, this.pageIndex, this.name, this.price, this.courseTypeId?.id).subscribe(
      Response => {
        console.log(Response);
        this.courses = Response.courses;
        this.totalRecords = Response.totalCount;
        this.loading = false;
      }
    );
  }

  search() {
    console.log(this.courseTypeId);
    this.loading = true;
    this.loadCourses(null);
  }
  navigateToAddPage() {
    this.router.navigateByUrl('/courses/create');
  }

  Delete(id: number) {
    this.confirmationService.confirm({
      message: 'Are you sure to delete this course?',
      accept: () => {
        this.courseService.DeleteCourse(id).subscribe(
          next => {
            this.loadCourses(null);
            this.messageService.add({ severity: 'success', summary: 'Deleted Done!' });
          },
          error => {
            this.messageService.add({ severity: 'error', summary: 'Error!!!' });

          }
        );
      }
    });
    // if (confirm('Are you sure to delete this user?')) {
    //   this.courseService.DeleteCourse(id).subscribe(
    //     result => {
    //       this.loadCourses(null);
    //       alert("Deleted Done!");

    //     }
    //   );
    // }
  }
}




