module Guild
  class Calculator
    def initialize(parser)
      @parser = parser
    end

    def add(input)
      sum_the(input)
    end

  private
    attr_reader :parser
    
    def sum_the(input)
      parse_the(input).inject(0, :+)
    end

    def parse_the(input)
      Array(parser.parse(input))
    end
  end
end
