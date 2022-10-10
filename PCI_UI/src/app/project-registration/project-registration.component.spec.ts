import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectRegistrationComponent } from './project-registration.component';

describe('ProjectRegistrationComponent', () => {
  let component: ProjectRegistrationComponent;
  let fixture: ComponentFixture<ProjectRegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectRegistrationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProjectRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
