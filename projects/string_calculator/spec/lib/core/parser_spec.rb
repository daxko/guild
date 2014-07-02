require 'spec_helper'

module Guild
  describe Parser do
    describe '#parse' do
      context 'when_parsing_on_a_comma' do
        it 'should_return_an_array_of_integers' do
          sut = Parser.new
          expect(sut.parse('1,2,3')).to eql([1, 2, 3])
        end
      end
    end
  end
end
