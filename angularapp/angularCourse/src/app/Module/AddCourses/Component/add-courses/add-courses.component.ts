import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Message, MessageService } from 'primeng/api';
import { ISessions, Icourse, IcoursesLevels, IcoursesTypes } from 'src/app/Module/Model/icourse';
import { CourseService } from 'src/app/Module/Service/course.service';

@Component({
  selector: 'app-add-courses',
  templateUrl: './add-courses.component.html',
  styleUrls: ['./add-courses.component.css']
})
export class AddCoursesComponent implements OnInit {
  show: Boolean = true;
  courses: Icourse[] = [];
  coursesTypes: IcoursesTypes[] = [];
  coursesLevels: IcoursesLevels[] = [];
  sessionArray: ISessions[] = [{ sessionName: '', durationInMins: 0 }, { sessionName: '', durationInMins: 0 }, { sessionName: '', durationInMins: 0 }];
  id: number = 0;

  constructor(
    private fb: FormBuilder,
    private service: CourseService,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,

  ) { }
  ngOnInit(): void {
    this.service.getCoursesTypes().subscribe(coursesTypes => this.coursesTypes = coursesTypes);
    this.service.getCoursesLevels().subscribe(coursesLevels => this.coursesLevels = coursesLevels);
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.id);
    if (this.id) {
      this.show = false;
      this.getData();

    }
  }
  getData() {
    this.service.getCoursesById(this.id).subscribe((course: Icourse) => {

      let sessions: any = course.session;

      this.courseForm.patchValue({
        name: `${course.name}`,
        description: `${course.description}`,
        courseTypeId: `${course.courseType.id}`,
        price: `${course.price}`,
        courseLevelId: `${course.courseLevel.id}`,
        sessions: sessions
      })
    });
  }

  courseForm = this.fb.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    courseTypeId: ['', [Validators.required]],
    price: ['', [Validators.required]],
    courseLevelId: ['', [Validators.required]],
    sessions: this.fb.array([
      this.fb.group({
        sessionName: ['', [Validators.required]],
        durationInMins: ['', [Validators.required]]
      }),
      this.fb.group({
        sessionName: '',
        durationInMins: ''
      }),
      this.fb.group({
        sessionName: '',
        durationInMins: ''
      })
    ])
  });


  get name() {
    return this.courseForm.controls.name as FormControl;
  }
  get description() {
    return this.courseForm.controls.description as FormControl;
  }
  get courseTypeId() {
    return this.courseForm.controls.courseTypeId as FormControl;
  }
  get price() {
    return this.courseForm.controls.price as FormControl;
  }
  get courseLevelId() {
    return this.courseForm.controls.courseLevelId as FormControl;
  }
  get sessions() {
    return this.courseForm.controls.sessions as FormArray;
  }

  Add() {
    var formData = this.courseForm.value;
    formData.sessions = this.courseForm.value.sessions?.filter(session => {
      return session.durationInMins && session.sessionName;
    });
    console.log(formData.sessions);
    this.service.AddCourse(formData).subscribe(
      result => {
        this.messageService.add({ severity: 'success', summary: 'Confirmed', detail: 'Record added' });

        console.log(this.courseForm.value);
        setTimeout(() => {
          this.router.navigate(['courses']);
        }, 500);

        this.courseForm.reset();
      }
    );
  }


  Update() {
    console.log({ ...this.courseForm.value, 'id': this.id });
    const newCourse: any = {
      id: this.id,
      name: this.name.value,
      description: this.description.value,
      courseTypeId: this.courseTypeId.value,
      price: this.price.value,
      courseLevelId: this.courseLevelId.value,
      sessions: this.sessions.value
    }
    this.service.UpdateCourse(this.id,newCourse).subscribe(
      result => {
        this.messageService.add({ severity: 'success', summary: 'Confirmed', detail: 'Record updated' });
        setTimeout(() => {
          this.router.navigate(['courses']);
        }, 700);
        this.courseForm.reset();


      }
    );

  }
  // courseForm.get('sessions').controls
  cancel() { this.router.navigate(['courses']); }
}
