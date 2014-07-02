module Guild
  class Calculator
    def initialize(parser)
      @parser = parser
    end

    def add(input)
      parser.parse(input).inject(0, :+)
    end

  private
    attr_reader :parser
  end
end
