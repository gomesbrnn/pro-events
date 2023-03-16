import { DateTimeFormatPipe } from './date-time-format.pipe';

describe('DateTimeFormat', () => {
  it('create an instance', () => {
    const pipe = new DateTimeFormatPipe('pt-BR');
    expect(pipe).toBeTruthy();
  });
});
