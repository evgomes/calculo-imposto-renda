import { ErrorHandler, NgZone, Inject } from "@angular/core";
import { ToastrService } from "ngx-toastr";

export class AppErrorHandler implements ErrorHandler {
    
    constructor(@Inject(NgZone) private ngZone: NgZone, @Inject(ToastrService) private toastrService: ToastrService) {
    }

    handleError(error: any): void {
        this.ngZone.run(() => {
            this.toastrService.error('Ocorreu um erro: ' + error);
            console.log(error);
        });
    }

}