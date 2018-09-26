import { Injectable } from "@angular/core";
import { CanDeactivate } from "@angular/router";
import { EditProfileComponent } from "../edit-profile/edit-profile.component";

@Injectable()

export class PreventUnsavedChanges implements CanDeactivate<EditProfileComponent> {
    canDeactivate(component: EditProfileComponent) {
        if (component.editForm.dirty) {
            return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
        }
        return true;
    }
}
