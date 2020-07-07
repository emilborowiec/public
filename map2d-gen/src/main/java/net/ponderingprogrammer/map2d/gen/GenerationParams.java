package net.ponderingprogrammer.map2d.gen;

import java.util.Collection;

public interface GenerationParams {
    boolean isValid();
    Collection<String> getViolations();
}
