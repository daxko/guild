module Guild
  class Parser
    def parse(input)
      input.split(',')
           .map { |i| Integer(i) }
    end
  end
end
