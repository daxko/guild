require 'spec_helper'

module Guild
  describe Calculator do

    before(:each) do
      @parser = double('parser')
      @sut    = Calculator.new(@parser)
    end

    describe '#add' do
      context 'when_passed_input' do
        it 'should_sum_up_the_input' do
          @parser.stub(:parse).and_return([1,2,3])
          expect(@sut.add('1,2,3')).to eql(6) 
        end
      end
    end
  end
end
