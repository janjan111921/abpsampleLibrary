import { libraryTemplatePage } from './app.po';

describe('library App', function() {
  let page: libraryTemplatePage;

  beforeEach(() => {
    page = new libraryTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
