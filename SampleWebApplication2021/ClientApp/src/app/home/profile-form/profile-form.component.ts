import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as dto from "app/services/dto";

@Component({
  selector: 'app-profile-form',
  templateUrl: './profile-form.component.html',
  styleUrls: ['./profile-form.component.less']
})
export class ProfileFormComponent implements OnInit {
  @Input()
  positions: dto.EmployeePosition[];
  @Input()
  activeEmployee: dto.Employee;

  @Output()
  onSave: EventEmitter<dto.Employee> = new EventEmitter();

  profileForm: FormGroup;

  constructor() {
    this.profileForm = new FormGroup({
      fullName: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required]),
      positionID: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit() {
  }

  ngOnChanges() {
    if (this.activeEmployee)
      this.profileForm.setValue({
        fullName: this.activeEmployee.fullName,
        address: this.activeEmployee.address,
        phoneNumber: this.activeEmployee.phoneNumber,
        positionID: this.activeEmployee.positionID,
      });
  }

  onSubmit() {
    this.onSave.emit(this.profileForm.value as dto.Employee)
  }

}
