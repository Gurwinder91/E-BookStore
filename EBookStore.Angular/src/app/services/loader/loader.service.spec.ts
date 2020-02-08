import { LoaderService, LoaderState } from './loader.service';

describe('Loader Service', () => {
    let service: LoaderService;

    beforeEach(() => {
        service = new LoaderService();
    });

    it('should have instance', () => {
        expect(service).toBeTruthy();
    });

    it('should populate default properties', () => {
        expect(service.loaderState).toBeTruthy();
    });

    it('should hide and show methods', () => {
        expect(service.hide).toBeTruthy();
        expect(service.show).toBeTruthy();
    });

    it('show method should emit event', () => {
        service.loaderState.subscribe((res: LoaderState) => {
            expect(res.show).toBeTruthy();
        });
        service.show();
    });

    it('hide method should emit event', () => {
        service.loaderState.subscribe((res: LoaderState) => {
            expect(res.show).toBeFalsy();
        });
        service.hide();
    });

});
