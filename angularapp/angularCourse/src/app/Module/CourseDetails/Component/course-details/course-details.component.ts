import { CourseService } from 'src/app/Module/Service/course.service';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ISessions, Icourse, IcoursesLevels, IcoursesTypes } from 'src/app/Module/Model/icourse';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent {
  course: Icourse | undefined;
  session: any;
  id: any;

  constructor(
    private courseService: CourseService,
    private router: Router,
    private route: ActivatedRoute) {
    this.courseService.getSessions().subscribe(result => { this.session = result });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    this.courseService.getCoursesById(id).subscribe(course => {
      this.course = course;
      console.log(course);
    });
  }

  back() { this.router.navigate(['courses']); }
}
