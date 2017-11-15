# class的示例
#java风格
class Apple
    def initialize
        #instance varible
        @color
    end

    #getter
    def color
        return @color
    end

    #setter
    def color=color
        @color=color
    end

    #private
    private
    def i_am_private
    end
end

#ruby风格
class Peach
    #同时声明了@color，setter，getter
    attr_accessor "color"
end

red_apple=Apple.new
red_apple.color = "red"
puts "red_apple.color:#{red_apple.color}"

green_peach=Peach.new
green_peach.color = "green"
puts "green_peach.color:#{green_peach.color}"

